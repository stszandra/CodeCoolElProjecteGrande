package com.codecool.the_recruitables.offer_oasis_tests.pageFactory;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.PageFactory;

public class MyCartPage {
    WebDriver chromedriver;

    public MyCartPage(WebDriver driver){
        this.chromedriver=driver;
        PageFactory.initElements(driver, this);
        chromedriver.manage().window().maximize();
    }
}
