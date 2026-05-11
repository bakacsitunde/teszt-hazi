using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace WebTester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            IWebDriver driver = new ChromeDriver(options);

            try
            {
                driver.Navigate().GoToUrl("http://localhost/urlap.html");
                Thread.Sleep(500); 


                var nameInput = driver.FindElement(By.Id("name"));
                nameInput.SendKeys("Nagy Margit");
                await Task.Delay(500);

                var emailInput = driver.FindElement(By.Id("email"));
                emailInput.SendKeys("margit@gmail.com");
                await Task.Delay(500);

                var phoneInput = driver.FindElement(By.Id("phone"));
                phoneInput.SendKeys("06204574916");
                await Task.Delay(500); 

                var passwordInput = driver.FindElement(By.Id("password"));
                passwordInput.SendKeys("tesztel34");
                await Task.Delay(500); 


                var genderSelect = driver.FindElement(By.Id("female"));
                genderSelect.Click();
                await Task.Delay(500);

                var subscribeCheckbox = driver.FindElement(By.Id("subscribe"));
                subscribeCheckbox.Click();
                await Task.Delay(500);

                var countrySelect = driver.FindElement(By.Id("country"));
                SelectElement select = new SelectElement(countrySelect);
                select.SelectByText("USA");
                await Task.Delay(500);

                IJavaScriptExecutor js= (IJavaScriptExecutor)driver;
                js.ExecuteScript("document.getElementById('birthdate').value='2000-04-06';");
                await Task.Delay(500);


                var messageInput = driver.FindElement(By.Id("message"));
                messageInput.SendKeys("Ez egy rövid teszt üzenet.");
                await Task.Delay(2000);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}















