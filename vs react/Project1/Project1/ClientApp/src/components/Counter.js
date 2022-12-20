import React, { Component } from 'react';
import { useEffect, useState } from "react";


export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }
    
  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div>
            
            <br />
            <br />
            <img src="E:\\MCDA\\vs react\\Project1\\Project1\\Capture.PNG"/><br />
            <br />
            <h2><b>I live in Surat.</b></h2><br />
            <br />
            <p>Surat is a city located in Gujarat in India. It is also known as Diamond hub.
               Surat is also know for its textile market.</p>
            <br />
            <br />
            <img src="E:\\MCDA\\vs react\\Project1\\Project1\\weather.png" /><br />
            <p>-1&deg;C</p>
        </div>
    );
  }
}
