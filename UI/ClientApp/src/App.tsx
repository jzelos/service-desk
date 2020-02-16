import React from 'react';
import './App.css';
import NavBarComponent from './Pages/NavBarComponent';
import { Route, Link, BrowserRouter as Router } from 'react-router-dom'
import UnassignedRequestsComponent from './Pages/UnassignedRequestsComponent';
import MyRequestsComponent from './Pages/MyRequestsComponent';
import MyTeamsRequestsComponent from './Pages/MyTeamsRequestsComponent';

const App = () => {
  return (
    <div className="app"> 
      <NavBarComponent />
      <div className="body">                
        <Router>
          <Route path="/myrequests" component={MyRequestsComponent} />
          <Route path="/myteamsrequests" component={MyTeamsRequestsComponent} />
          <Route path="/unassignedrequests" component={UnassignedRequestsComponent} />
        </Router>
      </div>            
    </div>
  );
}

export default App;