using Business.Dialogs;
using Business.Services;

var contactService = new ContactService();
var menuService = new MenuService(contactService);
var menuDialog = new MenuDialog(menuService);

menuDialog.MenuOptionsDialog();