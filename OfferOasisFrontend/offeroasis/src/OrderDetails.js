import React, { useEffect, useState } from 'react';

export default function OrderDetails() {
    const token = localStorage.getItem('token');
    const [responseStatus, setResponseStatus] = useState(null);

    useEffect(() => {
        fetch('https://localhost:7193/products', {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
        })
            .then(response => {
                setResponseStatus(response.status); 
            })
            .catch(error => {
                console.log(error);
            });
    }, []);

    return (
        <div className="h-auto">
            {responseStatus === 200 ? (
                // Render your product details here if the response is OK (status code 200)
                <div class="w-full max-w-smborder border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
                  List of previous orders!
                </div>
            ) : (
               <div> 
             <h1 className="mb-4 text-center flex-1 justify-center text-xl font-extrabold text-gray-900 dark:text-white md:text-xl lg:text-2xl">
    <span className=" text-transparent bg-clip-text bg-gradient-to-r to-green-900 from-red-900">Dear</span> valued customer,
</h1>

               <div className="flex" > 
               <div className='w-1/2'>
               <div className=' ml-10 font-bold text-transparent bg-clip-text bg-gradient-to-r to-green-900 from-red-900 md:underline-red'>
                Please register first before you can place an order</div>
                <div className='ml-10 text-justify'>
                 Our dedicated team is working diligently to prepare your order for shipment.
                Each item is carefully inspected, packaged, and dispatched to ensure it reaches you in perfect condition. 
                We partner with trusted shipping providers to guarantee a smooth and secure delivery process.
                Rest assured that your order is in capable hands, and we will keep you informed at every step of the way.
                If you have any questions or require further assistance, our customer support team is ready to help. Thank you for choosing us, and we look forward to serving you. Your satisfaction is our success.
                </div>
                </div>
               <div className='w-1/2'>
               <img src="https://cdn.smartkarrot.com/wp-content/uploads/2020/09/Satisfied-Customers.png" className="h-56 w-100 ml-16 border-double rounded-full" alt='' />
                 </div>
               </div>
               </div>
            )}
            <div className="flex" > 
               <div className='w-1/2'>
              
                <div className='ml-10 text-justify'>
                Rest assured that your order is in capable hands, and we will keep you informed at every step of the way. If you have any questions or require further assistance, our customer support team is ready to help. Thank you for choosing us, and we look forward to serving you.
                </div>
                </div>
               <div className='w-1/2'>
               <img src="data:image/jpeg;base64,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" className="h-56 w-100 ml-16 border-double rounded-full"  alt=''/>
                 </div>
               </div>
               <div className=' mt-7 text-3xl flex justify-center ml-10 font-bold text-transparent bg-clip-text bg-gradient-to-r to-green-900 from-red-900 md:underline-red'>
               Our Trusted Delivery Partners</div>
               
               <div className="flex" > 
               <div className='w-1/3'>
              <img src='https://presta.hu/32-large_default/foxpost.jpg '  className="h-56 w-100  border-double rounded-2xl mt-11 ml-48" alt=''/>
                </div>
               <div className='w-1/3'>
               <img src="https://www.gls-us.com/getmedia/c1a108d8-d659-4389-81ff-e80f8968b58a/Medium-GLS_Logo_2021_CMYK-GLSBlue_-FreightDescriptor_English.jpg " className="h-56 w-100 ml-16 border-double rounded-2xl mt-11"  alt=''/>
                 </div>
                 <div>
                 <img src='https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/United_Parcel_Service_logo_2014.svg/1200px-United_Parcel_Service_logo_2014.svg.png' class="h-56 w-100 ml-24 border-double rounded-2xl mt-11" alt=''/>
                 </div>
               </div>
               

        </div>
    );
}
