import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useEffect, useState } from "react";
import 'react-toastify/dist/ReactToastify.css';



export default function OrderDetails() {
  const token = localStorage.getItem('token');
  // const products = localStorage.getItem('products');
  const email = localStorage.getItem('email');
  const replacedEmail = email.replace('@', '%40');
  const [userData, setUserData] = useState([]);
  const [gProducts, setGProducts] = useState([]);

  let groupedProducts = [];
  if (localStorage.getItem('products')) {
    groupedProducts = JSON.parse(localStorage.getItem('products'));
  }

  useEffect(() => {
    fetch(`https://localhost:7193/users?email=${replacedEmail}`)
      .then(resp => resp.json())
      .then(data => setUserData(data))
    setGProducts(groupedProducts);
  }, [])

  const sendOrderDetailsData = async (event) => {
    event.preventDefault();
    // Send a POST request to the backend with the form data
    try {
      const response = await fetch(`https://localhost:7193/orders`,
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(
            {
              listOfOrderDetails: groupedProducts.map(orderDetail => ({ orderId: 0, orderDetailId: 0, productId: orderDetail.id, quantity: orderDetail.quantity, productPrice: orderDetail.price })),
              shippingType: 0,
              userId: userData.result.id,
              shippingAddress: userData.result.address,
              billingAddress: userData.result.address
            }

          )
        });
        
      if (response.ok) {
        toast('You succesfully placed your order');
        setGProducts([]);
        localStorage.removeItem('products')
      } else {
        toast('Order placement failed, please contact our helpdesk!')
      }


    } catch (error) {
      console.error('An error occurred:', error);
    }

  };

  function calculateTotalPrice(cart) {
    return groupedProducts.reduce((total, product) => total + product.price * product.quantity, 0);
  }
  const totalPrice = calculateTotalPrice(groupedProducts);

  function changeQuantity(e) {
    groupedProducts.find(o => o.id === e.target.id).quantity = e.target.valueAsNumber;
    setGProducts(groupedProducts);

    localStorage.setItem('products', JSON.stringify(groupedProducts));

  }
  function clearCart() {
    localStorage.removeItem('products');
    setGProducts([]);
  }
  return (
    <div className="h-auto">
      {token ? (
        <div className="mt-10 flex flex-col xl:flex-row jusitfy-center items-stretch  w-full xl:space-x-8 space-y-4 md:space-y-6 xl:space-y-0">
          <div className="flex flex-col justify-start items-start w-full space-y-4 md:space-y-6 xl:space-y-8">
            <div className="flex flex-col justify-start items-start bg-gray-50 px-4 py-4 md:py-6 md:p-6 xl:p-8 w-full">
              <p className="text-lg md:text-xl font-semibold leading-6 xl:leading-5 text-gray-800">Customer’s Cart</p>
              <p className="text-lg md:text-xl font-semibold leading-6 xl:leading-5 text-gray-800" hidden={groupedProducts.length!==0}>Go to our products page to place items in the cart</p>
              {gProducts.map(product =>
                <div className="mt-6 md:mt-0 flex justify-start flex-col md:flex-row  items-start md:items-center space-y-4  md:space-x-6 xl:space-x-8 w-full ">
                  <div className="w-full md:w-40">
                    <img className="w-full hidden md:block" src={product.imageUrl} alt="dress" />
                    <img className="w-full md:hidden" src="https://i.ibb.co/BwYWJbJ/Rectangle-10.png" alt="dress" />
                  </div>
                  <div className="  flex justify-between items-start w-full flex-col md:flex-row space-y-4 md:space-y-0  ">
                    <div className="w-full flex flex-col justify-start items-start space-y-8">
                      <h3 className="text-xl xl:text-2xl font-semibold leading-6 text-gray-800">{product.name}</h3>
                      <div className="flex justify-start items-start flex-col space-y-2">
                      </div>
                    </div>
                    <div className="flex justify-between space-x-8 items-start w-full">
                      <p className="text-base xl:text-lg leading-6">
                        ${product.price} <span className="text-red-300 line-through"> </span>
                      </p>
                      <input id={product.id} onChange={(e) => changeQuantity(e)} type='number' min='0'  defaultValue={product.quantity} max={product.quantityInStock}/> 
                      <p className="text-base xl:text-lg leading-6 text-gray-800">{product.quantity}{product.quantity > 1 ? 'pcs' : 'pc'}</p>
                      <p className="text-base xl:text-lg font-semibold leading-6 text-gray-800">${product.quantity * product.price}</p>
                    </div>
                  </div>
                </div>

              )}

            </div>
            <div className="flex justify-center md:flex-row flex-col items-stretch w-full space-y-4 md:space-y-0 md:space-x-6 xl:space-x-8">
              <div className="flex flex-col px-4 py-6 md:p-6 xl:p-8 w-full bg-gray-50 space-y-6   ">
                <h3 className="text-xl font-semibold leading-5 text-gray-800">Summary</h3>
                <div className="flex justify-center items-center w-full space-y-4 flex-col border-gray-200 border-b pb-4">
                  <div className="flex justify-between items-center w-full">
                    <p className="text-base leading-4 text-gray-800">Shipping</p>
                    <p className="text-base leading-4 text-gray-600">$0</p>
                  </div>
                </div>
                <div className="flex justify-between items-center w-full">
                  <p className="text-base font-semibold leading-4 text-gray-800">Total</p>
                  <p className="text-base font-semibold leading-4 text-gray-600">${totalPrice}</p>
                </div>
              </div>

            </div>
          </div>
          <div className="bg-gray-50 w-full xl:w-96 flex justify-between items-center md:items-start px-4 py-6 md:p-6 xl:p-8 flex-col ">
            <h3 className="text-xl font-semibold leading-5 text-gray-800">Customer</h3>
            <div className="flex  flex-col md:flex-row xl:flex-col justify-start items-stretch h-full w-full md:space-x-6 lg:space-x-8 xl:space-x-0 ">
              <div className="flex flex-col justify-start items-start flex-shrink-0">
                <div className="flex justify-center  w-full  md:justify-start items-center space-x-4 py-8 border-b border-gray-200">
                  <img src="https://i.ibb.co/5TSg7f6/Rectangle-18.png" alt="avatar" />
                  <div className=" flex justify-start items-start flex-col space-y-2">
                    <p className="text-base font-semibold leading-4 text-left text-gray-800">{localStorage.getItem('userName')}</p>

                  </div>
                </div>

                <div className="flex justify-center  md:justify-start items-center space-x-4 py-4 border-b border-gray-200 w-full">
                  <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M19 5H5C3.89543 5 3 5.89543 3 7V17C3 18.1046 3.89543 19 5 19H19C20.1046 19 21 18.1046 21 17V7C21 5.89543 20.1046 5 19 5Z" stroke="#1F2937" strokeLinecap="round" strokeLinejoin="round" />
                    <path d="M3 7L12 13L21 7" stroke="#1F2937" strokeLinecap="round" strokeLinejoin="round" />
                  </svg>
                  <p className="cursor-pointer text-sm leading-5 text-gray-800">{localStorage.getItem('email')}</p>
                </div>
              </div>
              <div className="flex justify-between xl:h-full  items-stretch w-full flex-col mt-6 md:mt-0">
                <div className="flex justify-center md:justify-start xl:flex-col flex-col md:space-x-6 lg:space-x-8 xl:space-x-0 space-y-4 xl:space-y-12 md:space-y-0 md:flex-row  items-center md:items-start ">
                  <div className="flex justify-center md:justify-start  items-center md:items-start flex-col space-y-4 xl:mt-8">
                    <p className="text-base font-semibold leading-4 text-center md:text-left text-gray-800">Shipping Address</p>
                    <p className="w-48 lg:w-full xl:w-48 text-center md:text-left text-sm leading-5 text-gray-600">{userData.length !== 0 ? userData.result.address : 'null'}</p>
                  </div>
                  <div className="flex justify-center md:justify-start  items-center md:items-start flex-col space-y-4 ">
                    <p className="text-base font-semibold leading-4 text-center md:text-left text-gray-800">Billing Address</p>
                    <p className="w-48 lg:w-full xl:w-48 text-center md:text-left text-sm leading-5 text-gray-600">{userData.length !== 0 ? userData.result.address : 'null'}</p>
                  </div>
                </div>
                <div className="flex w-full justify-center items-center md:justify-start md:items-start">
                  <button className="mt-6 md:mt-0 py-5 hover:bg-gray-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-800 border border-gray-800 font-medium w-96 2xl:w-full text-base leading-4 text-gray-800"  onClick={(event) => sendOrderDetailsData(event)} hidden={groupedProducts.length===0}>Place Order</button>
                  <ToastContainer />
                </div>
                <div className="flex w-full justify-center items-center md:justify-start md:items-start">
                  <button className="mt-6 md:mt-0 py-5 hover:bg-gray-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-800 border border-gray-800 font-medium w-96 2xl:w-full text-base leading-4 text-gray-800" onClick={() => clearCart()}  hidden={groupedProducts.length===0}>Clear cart</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <div className='h-screen'>
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
    </div>
  );
}
