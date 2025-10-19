#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
register_dev0RotInjector.py
Adds or removes a context menu item "dev0RotInjector" for .dll files.
Should be run from the folder containing dev0RotInjector.exe (or specify --exe).
Requires administrator privileges (will try to elevate via UAC automatically).

Usage:
    python register_dev0RotInjector.py  # install context menu
    python register_dev0RotInjector.py --uninstall  # remove context menu
    python register_dev0RotInjector.py --exe "C:\\path\\to\\dev0RotInjector.exe"  # specify exe path
"""
import os
import sys
import ctypes
from pathlib import Path
import winreg
import argparse

MENU_NAME = "dev0RotInjector"
ICON_SUBPATH = ""  # Optional: specify icon index/path, e.g., ",0" for first icon in exe
APP_URL = "https://github.com/backdoor831246"

def is_admin():
    """Check if the script is running with admin privileges."""
    try:
        return ctypes.windll.shell32.IsUserAnAdmin() != 0
    except Exception:
        return False

def relaunch_as_admin():
    """Relaunch the script with administrator privileges (UAC)."""
    params = " ".join(f'"{arg}"' for arg in sys.argv[1:])
    python_exe = sys.executable
    script = os.path.abspath(sys.argv[0])
    try:
        ctypes.windll.shell32.ShellExecuteW(None, "runas", python_exe, f'"{script}" {params}', None, 1)
        return True
    except Exception as e:
        print(f"Failed to request admin privileges: {e}")
        return False

def find_exe(provided_path=None):
    """Find the dev0RotInjector.exe file."""
    if provided_path:
        p = Path(provided_path)
        if p.is_file():
            return str(p.resolve())
        print(f"Provided path not found: {provided_path}")
    script_dir = Path(__file__).resolve().parent
    candidate = script_dir / "dev0RotInjector.exe"
    if candidate.is_file():
        return str(candidate)
    # Fallback: first .exe in folder
    for f in script_dir.iterdir():
        if f.suffix.lower() == ".exe":
            return str(f.resolve())
    return None

def create_context_menu(exe_path):
    """Create context menu for .dll files."""
    try:
        # For .dll files only
        base = rf"dllfile\shell\{MENU_NAME}"
        with winreg.CreateKeyEx(winreg.HKEY_CLASSES_ROOT, base, 0, winreg.KEY_WRITE) as k:
            winreg.SetValueEx(k, None, 0, winreg.REG_SZ, MENU_NAME)
            if ICON_SUBPATH:
                winreg.SetValueEx(k, "Icon", 0, winreg.REG_SZ, f"{exe_path},{ICON_SUBPATH}")
        cmd_key = base + r"\command"
        with winreg.CreateKeyEx(winreg.HKEY_CLASSES_ROOT, cmd_key, 0, winreg.KEY_WRITE) as k:
            winreg.SetValueEx(k, None, 0, winreg.REG_SZ, f'"{exe_path}" "%1"')
        print("Registry entries created successfully.")
        return True
    except PermissionError:
        print("Error: Not enough privileges to write to the registry.")
        return False
    except Exception as e:
        print(f"Error creating registry entries: {e}")
        return False

def delete_registry_key_recursive(root, subkey):
    """Recursively delete a registry key."""
    try:
        with winreg.OpenKey(root, subkey, 0, winreg.KEY_READ | winreg.KEY_WRITE) as key:
            while True:
                try:
                    child = winreg.EnumKey(key, 0)
                    delete_registry_key_recursive(root, subkey + "\\" + child)
                except OSError:
                    break
        winreg.DeleteKey(root, subkey)
        return True
    except FileNotFoundError:
        return False
    except PermissionError:
        print(f"Not enough privileges to delete {subkey}")
        return False
    except Exception as e:
        print(f"Error deleting {subkey}: {e}")
        return False

def uninstall_entries():
    """Remove context menu entries."""
    ok = False
    target = rf"dllfile\shell\{MENU_NAME}"
    res = delete_registry_key_recursive(winreg.HKEY_CLASSES_ROOT, target)
    if res:
        print(f"Deleted key: {target}")
        ok = True
    else:
        print(f"Key not found or not deleted: {target}")
    if ok:
        print("Uninstallation complete.")
    else:
        print("Nothing to remove or insufficient privileges.")

def main():
    parser = argparse.ArgumentParser(description="Installer for dev0RotInjector context menu")
    parser.add_argument("--uninstall", action="store_true", help="Remove registry entries")
    parser.add_argument("--exe", type=str, help="Path to dev0RotInjector.exe")
    args = parser.parse_args()

    if not is_admin():
        print("Requesting admin privileges...")
        if relaunch_as_admin():
            print("If UAC appeared, confirm. Script will continue in elevated session.")
            return
        else:
            print("Failed to elevate privileges. Run script as administrator manually.")
            return

    if args.uninstall:
        uninstall_entries()
        return

    exe = find_exe(args.exe)
    if not exe:
        print("dev0RotInjector.exe not found in current directory.")
        print("Place dev0RotInjector.exe next to the script or use --exe \"C:\\path\\to\\dev0RotInjector.exe\"")
        return

    print(f"Using exe: {exe}")
    if create_context_menu(exe):
        print("Done. Check Explorer context menu for .dll files (may require restarting Explorer).")

if __name__ == "__main__":
    main()