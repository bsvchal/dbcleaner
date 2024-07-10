@echo off
title Stop DBCleaner Service
if not "%1"=="am_admin" (
    powershell -Command "Start-Process -Verb RunAs -FilePath '%0' -ArgumentList 'am_admin'"
    exit /b
)
sc.exe stop DBCleaner
cls
echo Successfully stopped DBCleaner service!!!
pause