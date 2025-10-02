namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        //Bizim bağlantı işlemlerimizi gerçekleştircegimiz configrasyonlarımız.
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImagesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
