import { Outlet,useLocation } from 'react-router-dom'
import { useEffect,useState } from 'react'; 

export default function Navbar({ ...props }) {
  const [token, setToken] = useState(localStorage.getItem("token"));
  const name=localStorage.getItem("userName");
  const location = useLocation();
  useEffect(() => {
    setToken(localStorage.getItem('token'))
  }, [location]);

  const removeToken = () => {
    localStorage.removeItem("token");
  }
  return (
    <>
      <nav className="bg-red-50 shadow shadow-red-500 w-100 px-8 md:px-auto">
        <div className="md:h-16 h-28 mx-auto md:px-4 container flex items-center justify-between flex-wrap md:flex-nowrap">
          <div className="text-indigo-500 md:order-1">
            <svg xmlns="http://www.w3.org/2000/svg" className="h-10 w-10" fill="none" viewBox="0 0 24 24"
              stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2"
                d="M9 3v2m6-2v2M9 19v2m6-2v2M5 9H3m2 6H3m18-6h-2m2 6h-2M7 19h10a2 2 0 002-2V7a2 2 0 00-2-2H7a2 2 0 00-2 2v10a2 2 0 002 2zM9 9h6v6H9V9z" />
            </svg>
          </div>
          <div className="text-gray-500 order-3 w-full md:w-auto md:order-2 flex items-center">
            <ul className="flex font-semibold justify-between">
              <li className="md:px-4 md:py-2 text-indigo-500"><a href="/about">OfferOasis</a></li>
              <li className="md:px-4 md:py-2 hover:text-indigo-400"><a href="/products">Products</a></li>
              <li className="md:px-4 md:py-2 hover:text-indigo-400"><a href="/information">My Orders/Info</a></li>
              <li className="md:px-4 md:py-2 hover:text-indigo-400"><a href="/contact">Contact</a></li>
            </ul>
          </div>
          <div className="order-2 md:order-3 flex items-center">

  <div className="flex items-center gap-4">
    {token?
    <h4 className="text-gray-500">Logged in as {name}</h4>
: <></>  }

    <button className="px-4 py-2 bg-indigo-500 hover:bg-indigo-600 text-gray-50 rounded-xl flex items-center gap-2">
      <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
        <path fillRule="evenodd" d="M3 3a1 1 0 011 1v12a1 1 0 11-2 0V4a1 1 0 011-1zm7.707 3.293a1 1 0 010 1.414L9.414 9H17a1 1 0 110 2H9.414l1.293 1.293a1 1 0 01-1.414 1.414l-3-3a1 1 0 010-1.414l3-3a1 1 0 011.414 0z" clipRule="evenodd" />
      </svg>
      
      {token ? (
        <a href="/login" onClick={removeToken}><span>Logout</span></a>
      ) : (
        <a href="/login" ><span>Login/Register</span></a>
      )}
    </button>
  </div>
</div>
        </div>
      </nav>
      <Outlet />

      <footer className="bg-white rounded-lg shadow m-4 dark:bg-gray-800">
        <div className="w-full mx-auto max-w-screen-xl p-4 md:flex md:items-center md:justify-between">
          <span className="text-sm text-gray-500 sm:text-center dark:text-gray-400">© 2023 <a href="
	  /about" className="hover:underline">OfferOasis™</a>. All Rights Reserved.
          </span>
          <ul className="flex flex-wrap items-center mt-3 text-sm font-medium text-gray-500 dark:text-gray-400 sm:mt-0">
            <li>
              <a href="/about" className="mr-4 hover:underline md:mr-6 ">About</a>
            </li>
            <li>
              <a href="/terms" className="mr-4 hover:underline md:mr-6">Privacy Policy</a>
            </li>
            <li>
              <a href="/terms" className="mr-4 hover:underline md:mr-6">Licensing</a>
            </li>
            <li>
              <a href="/contact" className="hover:underline">Contact</a>
            </li>
          </ul>
        </div>
      </footer>

    </>
  )
}   