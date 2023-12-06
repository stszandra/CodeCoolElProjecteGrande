import { useState } from "react";
import { useEffect } from "react";


function App() {
  const [products,setProducts]=useState([]);
  useEffect(() => {
    fetch("https://localhost:7193/products")
  .then(resp=>resp.json())
  .then(data=>setProducts(data))
  }, [])
  console.log(products);
  return (
    products.length > 0 ? (
      <div>
      <div>
<section className="cards">
  {products.map(p=>
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
       <div className="inline-flex items-center px-3 py-2 text-sm font-medium text-center text-white bg-blue-700 rounded-lg hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
         Add to cart
            <svg className="w-3.5 h-3.5 ml-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 10">
               <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M1 5h12m0 0L9 1m4 4L9 9"/>
           </svg>
       </div>
   </div>
</div>

    )}
  </section>
        </div>
      </div>
    ) :(
      
      <p>Loading...</p>
  )
  )
    }
    


export default App;
