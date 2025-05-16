namespace Content.Features.StorageModule.Scripts {
    public class StorageFactory : IStorageFactory {
        public IStorage GetStorage() =>
            new StandardStorage();
    }
}