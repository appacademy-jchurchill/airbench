import React, { Component } from 'react';
import './App.css';

function Bench(props) {
  return (
    <tr>
      <td>{props.bench.description}</td>
      <td>{props.bench.numberOfSeats}</td>
      <td>{props.bench.latitude}/{props.bench.longitude}</td>
      <td>{props.bench.hasReviews === true ? props.bench.averageRating : 'No ratings'}</td>
      <td>{props.bench.userDisplayName}</td>
    </tr>
  );
}

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      benches: [],
      filteredBenches: [],
      minNumberOfSeats: null,
      maxNumberOfSeats: null
    };
  }

  filterBenches(benches, minNumberOfSeats, maxNumberOfSeats) {
    if (minNumberOfSeats === null) {
      minNumberOfSeats = NaN;
    }

    if (maxNumberOfSeats === null) {
      maxNumberOfSeats = NaN;
    }

    return benches.filter(bench => 
      (isNaN(minNumberOfSeats) && isNaN(maxNumberOfSeats)) ||
      (isNaN(minNumberOfSeats) && bench.numberOfSeats <= maxNumberOfSeats) ||
      (isNaN(maxNumberOfSeats) && bench.numberOfSeats >= minNumberOfSeats) ||
      (bench.numberOfSeats >= minNumberOfSeats && bench.numberOfSeats <= maxNumberOfSeats)
    );
  }

  handleMinChange = (event) => {
    const minNumberOfSeats = parseInt(event.target.value, 10);

    this.setState((state, props) => {
      const filteredBenches = this.filterBenches(state.benches, minNumberOfSeats, state.maxNumberOfSeats);

      return {
        filteredBenches: filteredBenches,
        minNumberOfSeats: minNumberOfSeats
      };
    });
  }

  handleMaxChange = (event) => {
    const maxNumberOfSeats = parseInt(event.target.value, 10);

    this.setState((state, props) => {
      const filteredBenches = this.filterBenches(state.benches, state.minNumberOfSeats, maxNumberOfSeats);

      return {
        filteredBenches: filteredBenches,
        maxNumberOfSeats: maxNumberOfSeats
      };
    });    
  }

  componentDidMount() {
    fetch('http://localhost:57497/api/benches')
      .then(response => response.json())
      .then(data => {
        this.setState({
          benches: data,
          filteredBenches: data
        });
      });
  }

  render() {
    return (
      <div>
        <h3>Benches</h3>
        <form className="form-inline">
          <div className="form-group">
            <label htmlFor="minNumberOfSeats">Min:</label>
            <input type="number" id="minNumberOfSeats" className="form-control" onChange={this.handleMinChange} />
          </div>
          <div className="form-group">
            <label htmlFor="maxNumberOfSeats">Max:</label>
            <input type="number" id="maxNumberOfSeats" className="form-control" onChange={this.handleMaxChange} />
          </div>
        </form>
        <table className="table">
          <thead>
              <tr>
                  <th>Description</th>
                  <th># of Seats</th>
                  <th>Lat/Long</th>
                  <th>Overall Rating</th>
                  <th>Posted By</th>
              </tr>
          </thead>
          <tbody>
            {this.state.filteredBenches.map(bench => (
              <Bench bench={bench} key={bench.benchId} />
            ))}
          </tbody>
        </table>    
    </div>
    );  
  }
}

export default App;
