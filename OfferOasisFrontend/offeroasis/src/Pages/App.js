import { useState, useEffect,useContext } from "react";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { globalContext } from "../Pages/Navbar";

function App() {
  const [products, setProducts] = useState([]);
  const token=localStorage.getItem("token");
  const userCart = JSON.parse(localStorage.getItem("cartDetails"));
  const { productType, setProductType } = useContext(globalContext)

  useEffect(() => {
      fetch("https://localhost:7193/products")
          .then(resp => resp.json())
          .then(data => {
              data.forEach(p => {
                  p.quantity = 1;
              })
              cartDetails_IntoProductsInLocalStorage(userCart, data);
              setProducts(data)
          })

          }, [])
    
  const cartDetails_IntoProductsInLocalStorage = (userCart, data) => {
        if (localStorage.getItem("productsInCart") == [] || localStorage.getItem("productsInCart") == null && userCart != null)
        {
            const productsInCart = data.filter(product => userCart.some(item => item.productId === product.id))
                .map(product => {
                    const cartItem = userCart.find(item => item.productId === product.id);
                    return {
                        ...product,
                        quantity: cartItem.quantity
                    }});

            localStorage.setItem('productsInCart', JSON.stringify(productsInCart));
        }
  }

  const addProductsToCart = (product) => {
      
    // if there's no cart, create empty cart with newly added product 
    if (localStorage.getItem('productsInCart') == null) {
      let cart = [];
      cart.push(product);
      localStorage.setItem('productsInCart', JSON.stringify(cart));
    }
    
    // increment quantity if product is already present OR add new product
    else {
      let cart = JSON.parse(localStorage.getItem('productsInCart'));
      let productAlreadyInCart = cart.find(p => p.id === product.id)
        
      productAlreadyInCart !== undefined 
          ? productAlreadyInCart.quantity++ 
          : cart.push(product)

      localStorage.setItem('productsInCart', JSON.stringify(cart));
    }
    toast(`${product.name} successfully added to the cart!`);
  }
  
  return (
    products.length > 0 ? (
      <div>
         {token ? (
              <></>
            ) : (
              <h2 className='mt-8 ml-10 font-bold text-transparent bg-clip-text bg-gradient-to-r to-green-900 from-red-900 md:underline-red  text-center text-xl' >
                Please login to add product to your cart!
              </h2>
            )}
        <div>
          <section className="cards grid grid-cols-3 ml-12 mt-12 ">
            {products.filter(product=>productType==null?product.name!=null:product.productTypeString==productType).map(p =>
              <div className="max-w-sm mb-6 w-64 bg-white border justify-center flex-col flex item-center border-gray-200 rounded-lg shadow dark:bg-gray-600 dark:border-gray-700" key={p.id}>
                <div className="flex justify-center" >
                  <img className="rounded-t-lg w-36" src={p.imageUrl} alt=""  />
                </div>
                <div className="p-5 h-1/2 content-between">
                  <div className="font-bold " >
                    <div className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white flex justify-center">{p.name}</div>
                  </div>
                  <p className="mb-3 font-normal text-gray-700 dark:text-gray-400 flex justify-center">{p.price} Euro</p>
                  <p className="mb-3 font-normal text-gray-700 dark:text-gray-400 flex justify-center">{p.quantityInStock} in stock</p>
                  {token ?
                    (<div>
                      <button onClick={() => addProductsToCart(p)} className=" rounded-lg mb-2 bg-indigo-500 border-0 py-2 px-8 focus:outline-none hover:bg-indigo-600 ml-8" > Add to Cart</button>
                      <ToastContainer />
                    </div>) : <div> </div>
                  }
                </div>
              </div>
            )}
          </section>
        </div>
      </div>
    ) : (
      <p>Loading...</p>
    )
  )
}

export default App;