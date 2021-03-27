/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 26.03.2021
 * Время: 3:16
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of DataContent.
	/// </summary>
	public partial class DataContent : UserControl
	{
		public DataContent()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public static string batDefault() {
			return  "@echo off"+"\n"+
					"setlocal"+"\n"+
					"set BASENAME=apktool_"+"\n"+
					"chcp 65001 2>nul >nul"+"\n\n"+
					
					"set java_exe=java.exe"+"\n\n"+
					
					"if defined JAVA_HOME ("+"\n"+
					"set java_exe=\"%JAVA_HOME%\\bin\\java.exe\""+"\n"+
					")"+"\n\n"+
					
					"rem Find the highest version .jar available in the same directory as the script"+"\n"+
					"setlocal EnableDelayedExpansion"+"\n"+
					"pushd \"%~dp0\""+"\n"+
					"if exist apktool.jar ("+"\n"+
					    "\t"+"set BASENAME=apktool"+"\n"+
					    "\t"+"goto skipversioned"+"\n"+
					")"+"\n"+
					"set max=0"+"\n"+
					"for /f \"tokens=1* delims=-_.0\" %%A in ('dir /b /a-d %BASENAME%*.jar') do if %%~B gtr !max! set max=%%~nB"+"\n"+
					":skipversioned"+"\n"+
					"popd"+"\n"+
					"setlocal DisableDelayedExpansion"+"\n\n"+
					
					"rem Find out if the commandline is a parameterless .jar or directory, for fast unpack/repack"+"\n"+
					"if \"%~1\"==\"\" goto load"+"\n"+
					"if not \"%~2\"==\"\" goto load"+"\n"+
					"set ATTR=%~a1"+"\n"+
					"if \"%ATTR:~0,1%\"==\"d\" ("+"\n"+
					    "\t"+"rem Directory, rebuild"+"\n"+
					    "\t"+"set fastCommand=b"+"\n"+
					")"+"\n"+
					"if \"%ATTR:~0,1%\"==\"-\" if \"%~x1\"==\".apk\" ("+"\n"+
					    "\t"+"rem APK file, unpack"+"\n"+
					    "\t"+"set fastCommand=d"+"\n"+
					")"+"\n\n"+
					
					":load"+"\n"+
					"%java_exe% -jar -Duser.language=en -Dfile.encoding=UTF8 \"%~dp0%BASENAME%%max%.jar\" %fastCommand% %*"+"\n\n"+
					
					"rem Pause when ran non interactively"+"\n"+
					"for /f \"tokens=2\" %%# in (\"%cmdcmdline%\") do if /i \"%%#\" equ \"/c\" pause";
		}
	}
}
