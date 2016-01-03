; 安装程序初始定义常量
!define PRODUCT_NAME "雅诗智能自动关机"
!define PRODUCT_VERSION "1.2.2"
!define PRODUCT_PUBLISHER "神楽坂雅詩"
!define PRODUCT_WEB_SITE "https://yoooooooooo.com/yashi/?p=4293"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\YashiAutoShutOff.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PRODUCT_STARTMENU_REGVAL "NSIS:StartMenuDir"

SetCompressor /SOLID lzma

; 提升安装程序权限(vista,win7,win8)
RequestExecutionLevel admin

; ------ MUI 现代界面定义 ------
!include "MUI2.nsh"

; MUI 预定义常量
!define MUI_ABORTWARNING
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\setup\Header.bmp"
!define MUI_HEADERIMAGE_UNBITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\setup\Header.bmp"
!define MUI_ICON "C:\Users\yashi\GitHub\YashiAutoShutOff\favicon.ico"
!define MUI_UNICON "C:\Users\yashi\GitHub\YashiAutoShutOff\favicon.ico"
!define MUI_WELCOMEFINISHPAGE_BITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\setup\Wizard.bmp"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\setup\Wizard.bmp"

; 欢迎页面
!insertmacro MUI_PAGE_WELCOME
; 许可协议页面
!insertmacro MUI_PAGE_LICENSE "C:\Users\yashi\GitHub\YashiAutoShutOff\setup\license.txt"
; 组件选择页面
!insertmacro MUI_PAGE_COMPONENTS
; 安装目录选择页面
!insertmacro MUI_PAGE_DIRECTORY
; 开始菜单设置页面
var ICONS_GROUP
!define MUI_STARTMENUPAGE_NODISABLE
!define MUI_STARTMENUPAGE_DEFAULTFOLDER "雅诗智能自动关机"
!define MUI_STARTMENUPAGE_REGISTRY_ROOT "${PRODUCT_UNINST_ROOT_KEY}"
!define MUI_STARTMENUPAGE_REGISTRY_KEY "${PRODUCT_UNINST_KEY}"
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "${PRODUCT_STARTMENU_REGVAL}"
!insertmacro MUI_PAGE_STARTMENU Application $ICONS_GROUP
; 安装过程页面
!insertmacro MUI_PAGE_INSTFILES
; 安装完成页面
!define MUI_FINISHPAGE_RUN "$INSTDIR\YashiAutoShutOff.exe"
!insertmacro MUI_PAGE_FINISH

; 安装卸载过程页面
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

; 安装界面包含的语言设置
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_LANGUAGE "SimpChinese"
!insertmacro MUI_LANGUAGE "TradChinese"

; ------ MUI 现代界面定义结束 ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "setup.exe"
ELiangID 56ZVL5NJHQ     /*  安装统计项名称：【雅诗智能自动关机】  */
InstallDir "$PROGRAMFILES\雅诗智能自动关机"
InstallDirRegKey HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
ShowInstDetails show
ShowUninstDetails show
BrandingText "Yashi Soft"

;安装包版本号格式必须为x.x.x.x的4组整数,每组整数范围0~65535,如:2.0.1.2
;若使用易量统计,版本号将用于区分不同版本的安装情况,此时建议用户务必填写正确的版本号
;!define INSTALL_VERSION "2.0.1.2"

;VIProductVersion "${INSTALL_VERSION}"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "ProductName"      "雅诗智能自动关机"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "Comments"         "雅诗智能自动关机(神楽坂雅詩)"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "CompanyName"      "神楽坂雅詩"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "LegalCopyright"   "神楽坂雅詩(https://yoooooooooo.com/yashi/?p=4293)"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "FileDescription"  "雅诗智能自动关机"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "ProductVersion"   "${INSTALL_VERSION}"
;VIAddVersionKey /LANG=${LANG_SimpChinese} "FileVersion"      "${INSTALL_VERSION}"

Section "主程序" SEC01
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiAutoShutOff.exe"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiAutoShutOff.exe.config"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiAutoShutOff.pdb"

; 创建开始菜单快捷方式
  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
  CreateDirectory "$SMPROGRAMS\$ICONS_GROUP"
  CreateDirectory "$DESKTOP\${PRODUCT_NAME}附件"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\雅诗智能自动关机.lnk" "$INSTDIR\YashiAutoShutOff.exe"
  CreateShortCut "$DESKTOP\雅诗智能自动关机.lnk" "$INSTDIR\YashiAutoShutOff.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\雅诗迷你定时关机.lnk" "$INSTDIR\YashiShutOffMini.exe"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}附件\雅诗迷你定时关机.lnk" "$INSTDIR\YashiShutOffMini.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\雅诗Windows性能计数器修复工具.lnk" "$INSTDIR\YashiAutoShutOffLodctr.exe"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}附件\雅诗Windows性能计数器修复工具.lnk" "$INSTDIR\YashiAutoShutOffLodctr.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\雅诗屏幕取色器.lnk" "$INSTDIR\YashiColorMeasurement.exe"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}附件\雅诗屏幕取色器.lnk" "$INSTDIR\YashiColorMeasurement.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\灭屏和休眠阻止工具.lnk" "$INSTDIR\SleepPreventer.exe"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}附件\灭屏和休眠阻止工具.lnk" "$INSTDIR\SleepPreventer.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\下载源代码.lnk" "$INSTDIR\YashiDownload.exe"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}附件\下载源代码.lnk" "$INSTDIR\YashiDownload.exe"
  !insertmacro MUI_STARTMENU_WRITE_END
SectionEnd

Section "信息显示工具" SEC02
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiMsgViewer\bin\Release\YashiMsgViewer.com"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiMsgViewer\bin\Release\YashiMsgViewer.iobj"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiMsgViewer\bin\Release\YashiMsgViewer.ipdb"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiMsgViewer\bin\Release\YashiMsgViewer.pdb"
SectionEnd

Section "屏幕取色器" SEC03
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiColorMeasurement\bin\Release\YashiColorMeasurement.exe"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiColorMeasurement\bin\Release\YashiColorMeasurement.exe.config"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiColorMeasurement\bin\Release\YashiColorMeasurement.pdb"
SectionEnd

Section "性能计数器修复工具" SEC04
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOffLodctr\bin\Release\YashiAutoShutOffLodctr.exe"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOffLodctr\bin\Release\YashiAutoShutOffLodctr.exe.config"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOffLodctr\bin\Release\YashiAutoShutOffLodctr.pdb"
SectionEnd

Section "灭屏和休眠阻止工具" SEC05
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\SleepPreventer-master\SleepPreventer\bin\Release\SleepPreventer.exe"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\SleepPreventer-master\SleepPreventer\bin\Release\SleepPreventer.pdb"
SectionEnd

Section "快捷定时关机工具" SEC06
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiShutOffMini\bin\Release\YashiShutOffMini.exe"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiShutOffMini\bin\Release\YashiShutOffMini.exe.config"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiShutOffMini\bin\Release\YashiShutOffMini.pdb"
SectionEnd

Section "LanguagePack:zh-CN" SEC07
  SetOutPath "$INSTDIR\Language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\Language\YashiAutoShutOff_zh-CN.language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiColorMeasurement\bin\Release\Language\YashiColorMeasurement_zh-CN.language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOffLodctr\bin\Release\Language\YashiAutoShutOffLodctr_zh-CN.language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\SleepPreventer-master\SleepPreventer\bin\Release\Language\SleepPreventer_zh-CN.language"
SectionEnd

Section "LanguagePack:zh-TW" SEC08
  SetOutPath "$INSTDIR\Language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\Language\YashiAutoShutOff_zh-TW.language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiColorMeasurement\bin\Release\Language\YashiColorMeasurement_zh-TW.language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOffLodctr\bin\Release\Language\YashiAutoShutOffLodctr_zh-TW.language"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\SleepPreventer-master\SleepPreventer\bin\Release\Language\SleepPreventer_zh-TW.language"
SectionEnd

Section "源代码下载器" SEC09
  SetOutPath "$INSTDIR"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiDownload\bin\Release\YashiDownload.exe"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiDownload\bin\Release\YashiDownload.exe.config"
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiDownload\bin\Release\YashiDownload.pdb"
SectionEnd

Section -AdditionalIcons
  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
  WriteINIStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\访问雅诗智能自动关机主页.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\卸载雅诗智能自动关机.lnk" "$INSTDIR\uninst.exe"
  !insertmacro MUI_STARTMENU_WRITE_END
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\YashiAutoShutOff.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\YashiAutoShutOff.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

; 区段组件描述
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC01} "Main program|雅诗智能自动关机的主程序。"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC02} "Information display tool|在主程序运行时，可以同步输出当前系统信息，可以作为条件输入参考。"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC03} "Screen color picker|可以帮助获取坐标和颜色代码，以便监控颜色模式下输入条件。"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC04} "Performance counter repair|Windows性能计数器有时会包含错误，导致本软件不能正常启动，可以尝试用此工具一键修复。"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC05} "Stop screen off and sleep|h46incon编写，在颜色测定模式下应阻止屏幕关闭和休眠，防止失败。"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC06} "Mini program|非常小巧的定时关机程序，极低占用系统资源。"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC07} "简体中文语言包|Simplified Chinese language pack"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC08} "繁體中文（臺灣）語言包|Traditional Chinese (Taiwan) language pack"
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC09} "source downloader|安装源代码下载器。"
!insertmacro MUI_FUNCTION_DESCRIPTION_END

/******************************
*  以下是安装程序的卸载部分  *
******************************/

Section Uninstall
  !insertmacro MUI_STARTMENU_GETFOLDER "Application" $ICONS_GROUP
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\YashiAutoShutOff.exe"
  Delete "$INSTDIR\YashiAutoShutOff.exe.config"
  Delete "$INSTDIR\YashiAutoShutOff.pdb"
  Delete "$INSTDIR\YashiMsgViewer.com"
  Delete "$INSTDIR\YashiMsgViewer.iobj"
  Delete "$INSTDIR\YashiMsgViewer.ipdb"
  Delete "$INSTDIR\YashiMsgViewer.pdb"
  Delete "$INSTDIR\YashiColorMeasurement.exe"
  Delete "$INSTDIR\YashiColorMeasurement.exe.config"
  Delete "$INSTDIR\YashiColorMeasurement.pdb"
  Delete "$INSTDIR\YashiAutoShutOffLodctr.exe"
  Delete "$INSTDIR\YashiAutoShutOffLodctr.exe.config"
  Delete "$INSTDIR\YashiAutoShutOffLodctr.pdb"
  Delete "$INSTDIR\SleepPreventer.exe"
  Delete "$INSTDIR\SleepPreventer.pdb"
  Delete "$INSTDIR\YashiShutOffMini.exe"
  Delete "$INSTDIR\YashiShutOffMini.exe.config"
  Delete "$INSTDIR\YashiShutOffMini.pdb"
  Delete "$INSTDIR\YashiAutoShutOff_zh-CN.language"
  Delete "$INSTDIR\YashiColorMeasurement_zh-CN.language"
  Delete "$INSTDIR\YashiAutoShutOffLodctr_zh-CN.language"
  Delete "$INSTDIR\SleepPreventer_zh-CN.language"
  Delete "$INSTDIR\YashiAutoShutOff_zh-TW.language"
  Delete "$INSTDIR\YashiColorMeasurement_zh-TW.language"
  Delete "$INSTDIR\YashiAutoShutOffLodctr_zh-TW.language"
  Delete "$INSTDIR\SleepPreventer_zh-TW.language"
  Delete "$INSTDIR\YashiDownload.exe"
  Delete "$INSTDIR\YashiDownload.exe.config"
  Delete "$INSTDIR\YashiDownload.exe.pdb"

  Delete "$SMPROGRAMS\$ICONS_GROUP\访问雅诗智能自动关机主页.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\卸载雅诗智能自动关机.lnk"

  Delete "$SMPROGRAMS\$ICONS_GROUP\雅诗智能自动关机.lnk"
  Delete "$DESKTOP\雅诗智能自动关机.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\雅诗迷你定时关机.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}附件\雅诗迷你定时关机.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\雅诗Windows性能计数器修复工具.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}附件\雅诗Windows性能计数器修复工具.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\雅诗屏幕取色器.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}附件\雅诗屏幕取色器.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\灭屏和休眠阻止工具.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}附件\灭屏和休眠阻止工具.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\下载源代码.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}附件\下载源代码.lnk"


  RMDir "$SMPROGRAMS\$ICONS_GROUP"
  RMDir "$DESKTOP\${PRODUCT_NAME}"

  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
SectionEnd

/* 根据 NSIS 脚本编辑规则,所有 Function 区段必须放置在 Section 区段之后编写,以避免安装程序出现未可预知的问题. */

Function un.onInit
FunctionEnd

Function un.onUninstSuccess
FunctionEnd
