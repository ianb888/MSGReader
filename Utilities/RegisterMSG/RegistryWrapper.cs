﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegisterMSG
{
    /// <summary>
    /// Provides a streamlined interface for reading and writing to the registry.
    /// </summary>
    class RegistryWrapper
    {
        /// <summary>
        /// Reads specified value from the registry.
        /// </summary>
        /// <param name="path">Full registry key (minus root) that contains value.</param>
        /// <param name="valueName">Name of the value within key that will be read.</param>
        /// <returns>Read value.</returns>
        public object Read(string path, string valueName)
        {
            RegistryKey key = Registry.ClassesRoot;
            string[] parts = path.Split('\\');

            if (parts == null || parts.Length == 0)
            {
                return null;
            }

            for (int x = 0; x < parts.Length; x++)
            {
                key = key.OpenSubKey(parts[x]);

                if (key == null)
                    return null;

                if (x == parts.Length - 1)
                {
                    return key.GetValue(valueName, null, RegistryValueOptions.DoNotExpandEnvironmentNames);
                }

            }

            return null;
        }

        /// <summary>
        /// Writes specified value to the registry.
        /// </summary>
        /// <param name="path">Full registry key (minus root) that will contain the value.</param>
        /// <param name="valueName">Name of the value within key that will be written.</param>
        /// <param name="value">Value to be written</param>
        public void Write(string path, string valueName, object value)
        {
            RegistryKey key = Registry.ClassesRoot;
            RegistryKey lastKey = key;
            string[] parts = path.Split('\\');

            if (parts == null || parts.Length == 0)
            {
                return;
            }

            for (int x = 0; x < parts.Length; x++)
            {
                key = key.OpenSubKey(parts[x], true);

                if (key == null)
                {
                    key = lastKey.CreateSubKey(parts[x]);
                }

                if (x == parts.Length - 1)
                {
                    if (value is string)
                    {
                        key.SetValue(valueName, value.ToString());
                    }
                    else if (value is uint || value.GetType().IsEnum)
                    {
                        object o = key.GetValue(valueName, null);

                        if (o == null)
                        {
                            key.SetValue(valueName, value, RegistryValueKind.DWord);
                        }
                        else
                        {
                            RegistryValueKind kind = key.GetValueKind(valueName);

                            if (kind == RegistryValueKind.DWord)
                            {
                                key.SetValue(valueName, value, RegistryValueKind.DWord);
                            }
                            else if (kind == RegistryValueKind.Binary)
                            {
                                uint num = (uint)value;

                                byte[] b = new byte[4];
                                b[0] = (byte)((num & 0x000000FF) >> 0);
                                b[1] = (byte)((num & 0x0000FF00) >> 1);
                                b[2] = (byte)((num & 0x00FF0000) >> 2);
                                b[3] = (byte)((num & 0xFF000000) >> 3);


                                b[0] = (byte)((num & 0x000000FF) >> 0);
                                b[1] = (byte)((num & 0x0000FF00) >> 8);
                                b[2] = (byte)((num & 0x00FF0000) >> 16);
                                b[3] = (byte)((num & 0xFF000000) >> 24);

                                key.SetValue(valueName, b, RegistryValueKind.Binary);
                            }
                            else if (kind == RegistryValueKind.String)
                            {
                                key.SetValue(valueName, "x" + ((uint)value).ToString("X8"));
                            }

                        }

                    }
                    else if (value is Guid)
                    {
                        key.SetValue(valueName, ((Guid)value).ToString("B"));
                    }

                }

                lastKey = key;
            }

            if (key != null)
                key.Close();
        }

        /// <summary>
        /// Deletes specified value;
        /// </summary>
        /// <param name="path">Full registry key (minus root) that contains the value to be deleted.</param>
        /// <param name="valueName">Name of value to be deleted</param>
        public void Delete(string path, string valueName)
        {
            RegistryKey key = Registry.ClassesRoot;
            string[] parts = path.Split('\\');

            if (parts == null || parts.Length == 0)
            {
                return;
            }

            for (int x = 0; x < parts.Length; x++)
            {
                key = key.OpenSubKey(parts[x], true);

                if (key == null)
                    return;

                if (x == parts.Length - 1)
                {
                    key.DeleteValue(valueName, false);
                }
            }
        }
    }
}