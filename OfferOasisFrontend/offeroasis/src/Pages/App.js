import { useState, useEffect } from "react";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  const [products, setProducts] = useState([]);
  useEffect(() => {
    fetch("https://localhost:7193/products")
      .then(resp => resp.json())
      .then(data => data.forEach(product => {
        product.quantity = 0;
      }))
      .then(data => setProducts(data))
  }, [])
  
  const addProductsToCart = (product) => {
    if (localStorage.getItem('products') === null) {
      let cart = [];
      cart.push(product);
      localStorage.setItem('products', JSON.stringify(cart));
      console.log(cart);
    }
    else {
      let cart = JSON.parse(localStorage.getItem('products'));
      for (let i = 0; i < cart.length; i++) {
        if (cart[i].id==product.id) {
        cart[i].quantity=cart[i].quantity+1;
        }
      }
      cart.push(product);
      localStorage.setItem('products', JSON.stringify(cart));
      console.log(cart);
    }
    toast(`${product.name} succesfully added to the cart!`);

  }
  return (
    products.length > 0 ? (
      <div>
        <div>
          <section className="cards">
            {products.map(p =>
              <div className="max-w-sm  bg-white border justify-center flex-1 item-center border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700" key={p.id}>
                <div>
                  <img className="rounded-t-lg w-1/2 h-1/2 " src={p.imageUrl} alt="" />
                </div>
                <div className="p-5">
                  <div className="font-bold" >
                    <div className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white "></div>
                  </div>{p.name}
                  <p className="mb-3 font-normal text-gray-700 dark:text-gray-400">{p.productType}</p>
                  <p className="mb-3 font-normal text-gray-700 dark:text-gray-400">{p.price} Euro</p>
                  <p className="mb-3 font-normal text-gray-700 dark:text-gray-400">{p.quantity} in stock</p>
                  <div>
                    <button onClick={() => addProductsToCart(p)} className=" bg-indigo-500 border-0 py-2 px-8 focus:outline-none hover:bg-indigo-600"> Add to Cart</button>
                    <ToastContainer />
                  </div>

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
