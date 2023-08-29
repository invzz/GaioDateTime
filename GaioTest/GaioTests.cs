using gaioDateTime;

namespace GaioTest
{
    [TestClass]
    public class GaioTests
    {
        [DataTestMethod]
        [DataRow("1/1/1999")]
        [DataRow("1/1/2003")]
        public void ShouldBeCapoCiclo(string date)
        {
            DateTime datetime = DateTime.Parse(date);
            GaioDateTime d = new GaioDateTime(datetime);
            Assert.IsTrue(d.IsCapoCiclo);
        }
        [DataTestMethod]
        [DataRow("2/1/1999")]
        [DataRow("2/1/2000")]
        [DataRow("1/1/2001")]
        [DataRow("1/1/2002")]
        [DataRow("2/1/2003")]
        public void ShouldBeCapodanno(string date)
        {
            DateTime datetime = DateTime.Parse(date);
            GaioDateTime d = new GaioDateTime(datetime);
            Assert.IsTrue(d.IsCapodanno);
        }
             
        
    }
}