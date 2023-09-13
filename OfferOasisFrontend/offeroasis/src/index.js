import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import RegisterForm from './RegisterForm';
import About from "./About";

ReactDOM.render(
  <Router>
    <React.StrictMode>
      <Routes>
        <Route path="/products" element={<App />} />
        <Route path="/account" element={<RegisterForm/>} />
        <Route path="/about" element={<About />} />
      </Routes>
    </React.StrictMode>
  </Router>,
  document.getElementById('root')
);

reportWebVitals();
