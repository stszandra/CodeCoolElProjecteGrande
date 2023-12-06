export default function OrderDetails() {
    const token = localStorage.getItem('token');

    /*useEffect(() => {
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
    }, []);*/
    return (
        <div className="h-auto">
            { token? (
                // Render your product details here if the response is OK (status code 200)
                <div className="w-full max-w-smborder border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
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
           
            {/* <div className="flex" > 
               <div className='w-1/2'>
                <div className='ml-10 text-justify'>
                Rest assured that your order is in capable hands, and we will keep you informed at every step of the way. If you have any questions or require further assistance, our customer support team is ready to help. Thank you for choosing us, and we look forward to serving you.
                </div>
                </div>
               <div className='w-1/2'>
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
                 <img src='https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/United_Parcel_Service_logo_2014.svg/1200px-United_Parcel_Service_logo_2014.svg.png' className="h-56 w-100 ml-24 border-double rounded-2xl mt-11" alt=''/>
                 </div>
               </div> */}
               

        </div>
    );
}
