; 该脚本使用 易量安装(az.eliang.com) 向导生成
; 安装程序初始定义常量
!define PRODUCT_NAME "雅诗智能自动关机"
!define PRODUCT_VERSION "1.1"
!define PRODUCT_PUBLISHER "神楽坂雅詩"
!define PRODUCT_WEB_SITE "https://yoooooooooo.com/yashi/?p=4293"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\YashiAutoShutOff.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"
!define PRODUCT_STARTMENU_REGVAL "NSIS:StartMenuDir"

SetCompressor /SOLID lzma
SetCompressorDictSize 32

; 提升安装程序权限(vista,win7,win8)
RequestExecutionLevel admin

; ------ MUI 现代界面定义 ------
!include "MUI2.nsh"

; MUI 预定义常量
!define MUI_ABORTWARNING
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\Resources\mingYSN.png"
!define MUI_HEADERIMAGE_UNBITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\Resources\mingYSN.png"
!define MUI_ICON "C:\Users\yashi\GitHub\YashiAutoShutOff\favicon.ico"
!define MUI_UNICON "C:\Users\yashi\GitHub\YashiAutoShutOff\favicon.ico"
!define MUI_WELCOMEFINISHPAGE_BITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\Resources\mingYSN.png"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\Resources\mingYSN.png"

; 欢迎页面
!insertmacro MUI_PAGE_WELCOME
; 许可协议页面
!define MUI_LICENSEPAGE_RADIOBUTTONS
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
!insertmacro MUI_LANGUAGE "SimpChinese"

; ------ MUI 现代界面定义结束 ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "setup.exe"
ELiangID 56ZVL5NJHQ     /*  安装统计项名称：【雅诗智能自动关机】  */
InstallDir "$PROGRAMFILES\雅诗智能自动关机"
InstallDirRegKey HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
ShowInstDetails show
ShowUninstDetails show
BrandingText "Kagurazaka Yashi"

;安装包版本号格式必须为x.x.x.x的4组整数,每组整数范围0~65535,如:2.0.1.2
;若使用易量统计,版本号将用于区分不同版本的安装情况,此时建议用户务必填写正确的版本号
!define INSTALL_VERSION "1.1.0.0"

VIProductVersion "${INSTALL_VERSION}"
VIAddVersionKey /LANG=${LANG_SimpChinese} "ProductName"      "雅诗智能自动关机"
VIAddVersionKey /LANG=${LANG_SimpChinese} "Comments"         "雅诗智能自动关机(神楽坂雅詩)"
VIAddVersionKey /LANG=${LANG_SimpChinese} "CompanyName"      "神楽坂雅詩"
VIAddVersionKey /LANG=${LANG_SimpChinese} "LegalCopyright"   "神楽坂雅詩(https://yoooooooooo.com/yashi/?p=4293)"
VIAddVersionKey /LANG=${LANG_SimpChinese} "FileDescription"  "雅诗智能自动关机"
VIAddVersionKey /LANG=${LANG_SimpChinese} "ProductVersion"   "${INSTALL_VERSION}"
VIAddVersionKey /LANG=${LANG_SimpChinese} "FileVersion"      "${INSTALL_VERSION}"

Section "雅诗智能关机" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiAutoShutOff.exe"

; 创建开始菜单快捷方式
  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
  CreateDirectory "$SMPROGRAMS\$ICONS_GROUP"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\雅诗智能自动关机.lnk" "$INSTDIR\YashiAutoShutOff.exe"
  CreateShortCut "$DESKTOP\雅诗智能自动关机.lnk" "$INSTDIR\YashiAutoShutOff.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\雅诗迷你定时关机.lnk" "$INSTDIR\YashiShutOffMini.exe"
  CreateShortCut "$DESKTOP\雅诗迷你定时关机.lnk" "$INSTDIR\YashiShutOffMini.exe"
  CreateShortCut "$SMPROGRAMS\$ICONS_GROUP\修复Windows性能计数器.lnk" "$INSTDIR\YashiAutoShutOffLodctr.exe"
  !insertmacro MUI_STARTMENU_WRITE_END
SectionEnd

Section "HTTP链接库" SEC05
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\System.Net.Http.dll"
SectionEnd

Section "雅诗定时关机mini" SEC03
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiShutOffMini.exe"
SectionEnd

Section "Windows性能计数器修复工具" SEC04
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiAutoShutOffLodctr.exe"
SectionEnd

Section "雅诗系统信息显示器" SEC02
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "C:\Users\yashi\GitHub\YashiAutoShutOff\YashiAutoShutOff\bin\Release\YashiMsgViewer.com"
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
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC01} ""
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC02} ""
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC03} ""
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC04} ""
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC05} ""
!insertmacro MUI_FUNCTION_DESCRIPTION_END

/******************************
*  以下是安装程序的卸载部分  *
******************************/

Section Uninstall
  !insertmacro MUI_STARTMENU_GETFOLDER "Application" $ICONS_GROUP
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\YashiAutoShutOff.exe"
  Delete "$INSTDIR\System.Net.Http.dll"
  Delete "$INSTDIR\YashiShutOffMini.exe"
  Delete "$INSTDIR\YashiAutoShutOffLodctr.exe"
  Delete "$INSTDIR\YashiMsgViewer.com"

  Delete "$SMPROGRAMS\$ICONS_GROUP\访问雅诗智能自动关机主页.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\卸载雅诗智能自动关机.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\雅诗智能自动关机.lnk"
  Delete "$DESKTOP\雅诗智能自动关机.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\雅诗迷你定时关机.lnk"
  Delete "$DESKTOP\雅诗迷你定时关机.lnk"
  Delete "$SMPROGRAMS\$ICONS_GROUP\修复Windows性能计数器.lnk"

  RMDir "$SMPROGRAMS\$ICONS_GROUP"


  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
SectionEnd

/* 根据 NSIS 脚本编辑规则,所有 Function 区段必须放置在 Section 区段之后编写,以避免安装程序出现未可预知的问题. */

Function un.onInit
FunctionEnd

Function un.onUninstSuccess
FunctionEnd
