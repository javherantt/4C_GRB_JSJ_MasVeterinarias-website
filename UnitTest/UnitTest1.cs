using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            ChromeDriver driver = new ChromeDriver();
        }
        // Agregar un Producto Nuevo
        [Test]
        public void Test1()
        {
            ChromeDriver driver = new ChromeDriver();
            //Navegamos a la URL
            driver.Navigate().GoToUrl("https://flyer-app.herokuapp.com/producto/create/");
            //Llenar Formulario
            driver.FindElement(By.Id("name")).SendKeys("Shampoo");
            driver.FindElement(By.Id("marca")).SendKeys("Kind");
            driver.FindElement(By.Id("especie")).SendKeys("Perro");
            driver.FindElement(By.Id("raza")).SendKeys("yorkshire");
            driver.FindElement(By.Id("etapa")).SendKeys("Perros pequeños");
            driver.FindElement(By.Id("descripcion")).SendKeys("Nuestro nuevo Jabon para mascotas ayuda a repeler pulgas");
            driver.FindElement(By.Id("detalles")).SendKeys("Ayuda a repeler pulgas");
            driver.FindElement(By.Id("precio")).SendKeys("65");
            driver.FindElement(By.Id("stock")).SendKeys("2");
           

            driver.FindElement(By.Id("sendMessageButton")).Click();
            //Validacion  del alert al hacer un regitro exitoso
            var expectedAlertText = "Producto registrado";
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);


        }
    }
}