using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace TanuloTest
{
    public class UnitTest1
    {
        private readonly WindowsDriver driver;

        public UnitTest1()
        {
            var options = new AppiumOptions();

            options.AddAdditionalAppiumOption(
                "app",
                @"C:\Temp\TanulokJegyei\bin\Debug\net8.0-windows\TanulokJegyei.exe");

            options.AddAdditionalAppiumOption(
                "deviceName",
                "WindowsPC");

            driver = new WindowsDriver(
                new Uri("http://127.0.0.1:4723"),
                options);

            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(10);
        }

        [Fact]
        public void TanuloSzerkesztes_Test()
        {
            // Tanuló kiválasztása
            driver.FindElement(By.Name("Kiss Anna"))
                  .Click();

            // Szerkesztés gomb
            driver.FindElement(By.Name("Szerkesztés"))
                  .Click();

            Thread.Sleep(1000);

            // Név mező
            var nameBox = driver.FindElement(MobileBy.AccessibilityId("nameBox"));

            nameBox.Click();
            nameBox.SendKeys(Keys.Control + "a");
            nameBox.SendKeys(Keys.Delete);
            nameBox.SendKeys("Teszt Elek");

            // Matek mező
            var mathBox = driver.FindElement(MobileBy.AccessibilityId("mathBox"));

            mathBox.Click();
            mathBox.SendKeys(Keys.Control + "a");
            mathBox.SendKeys(Keys.Delete);
            mathBox.SendKeys("5");

            // Mentés
            driver.FindElement(By.Name("Mentés"))
                  .Click();

            Thread.Sleep(1000);

            // Ellenőrzés
            driver.FindElements(By.Name("Teszt Elek"))
                  .Count
                  .Should().BeGreaterThan(0);
        }

        [Fact]
        public void TanuloTorles_Test()
        {
            // Tanuló kiválasztása
            driver.FindElement(By.Name("Nagy Péter"))
                  .Click();

            // Törlés
            driver.FindElement(By.Name("Törlés"))
                  .Click();

            Thread.Sleep(1000);

            // Ellenőrzés
            driver.FindElements(By.Name("Nagy Péter"))
                  .Count
                  .Should().Be(0);
        }
    }
}