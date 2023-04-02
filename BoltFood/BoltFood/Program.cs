using BoltFood.Service.Services.Implementations;
using BoltFood.Service.Services.Interfaces;

IMenuService menuService = new MenuService();

await menuService.ShowMenuAsync();
