import { useState } from "react";
import { useEffect } from "react";


function App() {
  const [products, setProducts] = useState("");
  const[users,setUsers]=useState("");
  const[orders,setOrders]=useState("");
  useEffect(() => {
   fetch("https://localhost:7193/products")
   .then(resp=>resp.text())
   .then(data=>setProducts(data))
  }, [])
 

  useEffect(() => {
   fetch("https://localhost:7193/users")
   .then(resp=>resp.text())
   .then(data=>setUsers(data))
  }, [])
  useEffect(() => {
    fetch("http://localhost:5181/orders")
    .then(resp=>resp.text())
    .then(data=>setOrders(data))
   }, [])
  console.log(users);
  console.log(products);
  console.log(orders)
  return (
    <>
  

    <section class="articles">
  <article>
    <div class="article-wrapper">
      <figure>
        <img src="https://picsum.photos/id/1011/800/450" alt="" />
      </figure>
      <div class="article-body">
        <h2>{users}</h2>
        <p>
        People should be able to choose their clothing freely, and there's no objective reason why women should dress in fancy clothes. Dressing style is a matter of personal preference, and everyone should decide what makes them feel comfortable and confident. Dressing nicely is not about gender but about individual style and self-expression.
        </p>
        <a href="#" class="read-more">
          Buy now<span class="sr-only">about this is some title</span>
          <svg xmlns="http://www.w3.org/2000/svg" class="icon" viewBox="0 0 20 20" fill="currentColor">
            <path fill-rule="evenodd" d="M12.293 5.293a1 1 0 011.414 0l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-2.293-2.293a1 1 0 010-1.414z" clip-rule="evenodd" />
          </svg>
        </a>
      </div>
    </div>
  </article>
  <article>

    <div class="article-wrapper">
      <figure>
        <img src="https://picsum.photos/id/1005/800/450" alt="" />
      </figure>
      <div class="article-body">
        <h2>{products}</h2>
        <p>
        
Men should have the freedom to choose their clothing as they wish, just like women. There's no inherent requirement for men to dress in any particular way, and clothing should be a matter of personal style and comfort. People should feel free to express themselves through their clothing choices regardless of their gender.
        </p>
        <a href="#" class="read-more">
         Buy now <span class="sr-only">about this is some title</span>
          <svg xmlns="http://www.w3.org/2000/svg" class="icon" viewBox="0 0 20 20" fill="currentColor">
            <path fill-rule="evenodd" d="M12.293 5.293a1 1 0 011.414 0l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-2.293-2.293a1 1 0 010-1.414z" clip-rule="evenodd" />
          </svg>
        </a>
      </div>
    </div>
  </article>
  <article>

    <div class="article-wrapper">
      <figure>
        <img src="https://picsum.photos/id/103/800/450" alt="" />
      </figure>
      <div class="article-body">
        <h2>{orders}</h2>
        <p>
        Children's toys should encourage creativity and learning. Toys play a crucial role in a child's development by fostering their imagination and helping them acquire essential skills. It's important to choose toys that are age-appropriate and promote healthy development.
        </p>
        <a href="#" class="read-more">
        Buy now <span class="sr-only">about this is some title</span>
          <svg xmlns="http://www.w3.org/2000/svg" class="icon" viewBox="0 0 20 20" fill="currentColor">
            <path fill-rule="evenodd" d="M12.293 5.293a1 1 0 011.414 0l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-2.293-2.293a1 1 0 010-1.414z" clip-rule="evenodd" />
          </svg>
        </a>
      </div>
    </div>
  </article>
</section>
    </>

    
  );
}

export default App;
