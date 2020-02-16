import React from 'react';
import logo from './logo.svg';
import './LoadingIndicator.scss';

export const LoadingIndicator: React.FunctionComponent = () => {
    return (<div className="loading-indicator">
                <img src={logo} alt="loading image..."></img>
                <p>Loading...</p>
            </div>);
};

export default LoadingIndicator;