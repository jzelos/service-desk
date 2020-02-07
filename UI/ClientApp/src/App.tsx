import React from 'react';
import logo from './logo.svg';
import './App.css';
import MyTicketsComponent from './Pages/MyTicketsPage/MyTicketsComponent';

const App = () => {
  return (
    <div className="app">
      <header>  
        <span>Service Desk Test</span>
      </header>
      <div className="body">
        <MyTicketsComponent />
      </div>            
    </div>
  );
}

export default App;