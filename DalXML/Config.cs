namespace Dal
{
    internal static class Config
    {
        private static string xmlName="data-config";
        public static string xmlVersion="1.0";

		private static int productNum=1008;
		public static int ProductNum
        {
			get { return productNum++; }
		}
		private static int saleNum=41;

		public static int SaleNum
        {
			get { return saleNum++; }
		}


	}
}
