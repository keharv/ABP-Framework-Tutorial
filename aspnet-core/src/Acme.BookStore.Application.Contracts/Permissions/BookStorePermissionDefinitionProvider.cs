using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

            var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

            var authorsPermission = bookStoreGroup.AddPermission(
                BookStorePermissions.Authors.Default, L("Permissions:Authors"));
            authorsPermission.AddChild(
                BookStorePermissions.Authors.Create, L("Permissions:Authors.Create"));
            authorsPermission.AddChild(
                BookStorePermissions.Authors.Edit, L("Permissions:Authors.Edit"));
            authorsPermission.AddChild(
                BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));

            var librariesPermission = bookStoreGroup.AddPermission(
                BookStorePermissions.Libraries.Default, L("Permissions:Libraries"));
            librariesPermission.AddChild(
                BookStorePermissions.Libraries.Create, L("Permissions:Libraries.Create"));
            librariesPermission.AddChild(
                BookStorePermissions.Libraries.Edit, L("Permissions:Libraries.Edit"));
            librariesPermission.AddChild(
                BookStorePermissions.Libraries.Delete, L("Permissions:Libraries.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}