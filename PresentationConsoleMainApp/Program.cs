using Business.Dialogs;
using Business.Services;

var menuService = new MenuService();
var menuDialog = new MenuDialog(menuService);

menuDialog.MenuOptionsDialog();