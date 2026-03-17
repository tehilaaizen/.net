using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        private static string xmlName=@"data-config.xml";
        public static string xmlVersion="1.0";
		private static string SALE_NUM = "SaleNum";
		private static string PRODUCT_NUM = "ProductNum";

        private static int productNum;
		public static int ProductNum
        {
			get {
                XElement x = XElement.Load(xmlName);
				productNum= int.Parse(x.Element(PRODUCT_NUM).Value);
                x.Element(PRODUCT_NUM).SetValue((productNum+1).ToString());
				x.Save(xmlName);
				return productNum;
			}
		}
		private static int saleNum;

		public static int SaleNum
        {
			get {
				XElement x = XElement.Load(xmlName);
                saleNum = int.Parse(x.Element(SALE_NUM).Value);
                x.Element(SALE_NUM).SetValue((saleNum+1).ToString());
				x.Save(xmlName);
                return saleNum;
            }
		}


	}
}
