import React from "react";

const About = () => {
    return (
<div> 
             <h1 className="mb-4 text-center flex-1 justify-center text-xl font-extrabold text-gray-900 dark:text-white md:text-xl lg:text-2xl">
    <span className=" text-transparent bg-clip-text bg-gradient-to-r to-green-900 from-red-900">Our Mission</span> 
</h1>

               <div className="flex" > 
               <div className='w-1/2'>
               <div className=' ml-10 font-bold text-transparent bg-clip-text md:underline-red'>
                Please register first before you can place an order</div>
                <div className='ml-10 text-justify'>
                At OfferOasis, we are driven by a passion for excellence and a commitment to innovation. Our journey began with a simple idea: to provide solutions that make a meaningful difference in people's lives. Today, we have grown into a dynamic team of dedicated professionals who strive to exceed expectations.
                </div>
                </div>
               <div className='w-1/2'>
               <img src="https://ugc.production.linktr.ee/VTvB7OE8Tvy2h3rghfcM_eUo70UeLDQ437e2o" alt="" className="h-60 w-100 ml-16 border-double rounded-2xl"  />
                 </div>
               </div>
               <div className="flex"> 
               <div className='w-1/2'>
               <div className=' ml-10 font-bold text-transparent bg-clip-text md:underline-red' alt="">
                Please register first before you can place an order</div>
                <div className='ml-10 text-justify'>
                What Sets Us Apart
We differentiate ourselves through our unwavering dedication to quality, unmatched customer service, and a deep understanding of our customers' needs. We believe in not just meeting but exceeding expectations.
We are committed to fostering growth, both for our team members and the communities we serve. Sustainability, ethics, and social responsibility are integral to our operations.
                </div>
                </div>
               <div className='w-1/2'>
               <img src="https://linktr.ee/og/image/OfferOasis.jpg" className="h-60 w-1/2 mt-6 ml-16 border-double rounded-2xl ml-60" alt=""/>
                 </div>
               </div>
               </div>
             
               
    );
};

export default About;