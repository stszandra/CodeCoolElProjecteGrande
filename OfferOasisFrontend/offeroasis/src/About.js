import React from 'react'
import Navbar from "../src/Navbar";
import "../src/about.css"
function About() {
  return (
    <div className='div1'>
        <Navbar/>
<div class="tabs">
  <input class="input" name="tabs" type="radio" id="tab-1" checked="checked"/>
  <label class="label" for="tab-1">About us</label>
  <div class="panel">
    <h1>About us</h1>
    <p>OfferOasis is a dynamic and innovative company at the forefront of revolutionizing the way businesses and consumers connect. Founded with a vision to simplify and enhance the shopping experience, we have quickly emerged as a trusted platform that bridges the gap between merchants and savvy shoppers.</p>
  </div>
  <input class="input" name="tabs" type="radio" id="tab-2"/>
  <label class="label" for="tab-2">Our Mission</label>
  <div class="panel">
    <h1>Our Mission</h1>
    <p>Our mission at OfferOasis is to empower consumers with access to exclusive deals, discounts, and promotions, while also providing businesses with a cutting-edge marketing channel to reach their target audience effectively. With a commitment to excellence and a passion for innovation, OfferOasis is poised to redefine the world of commerce. Join us on this exciting journey towards a brighter and more rewarding shopping future.</p>
  </div>
  <input class="input" name="tabs" type="radio" id="tab-3"/>
  <label class="label" for="tab-3">Enjoy the shopping</label>
  <div class="panel">
    <h1>Exploring New Frontiers in Shopping</h1>
    <p>At OfferOasis, we pride ourselves on fostering a vibrant and inclusive community of shoppers and businesses alike. Our dedicated team works tirelessly to curate a diverse range of offers, ensuring that everyone can find something that suits their needs and preferences. Whether you're a small boutique or a large retailer, OfferOasis is the perfect platform to showcase your products and connect with a highly engaged audience. Join us today, and let's transform the way you shop and do business.</p>
  </div>
</div>     
<div class="container">
  <h1 contenteditable className='work'>OUR WORKERS</h1>
</div>
   
</div>
  )
}

export default About