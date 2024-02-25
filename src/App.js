import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import News from './pages/news';
import AddPostForm from './pages/addnews';
import PaymentDetails from './pages/paymentdetails';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/news" element={<News />} />
        <Route path="/addnews" element={<AddPostForm />} />
        <Route path="/payinfor" element={<PaymentDetails />} />
      </Routes>
    </Router>
  );
}

export default App;
