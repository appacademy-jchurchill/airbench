
const airBenchBenchesHtml = (() => {
  function getTableHtml(benches) {
    // If we don't have any benches to display, return null.
    if (benches.length === 0) {
      return null;
    }

    const tableRowsHtml = benches.map(bench => `
      <tr>
        <td>${bench.description}</td>
        <td>${bench.numberOfSeats}</td>
        <td>${bench.latitude}/${bench.longitude}</td>
        <td>${bench.hasReviews === true ? bench.averageRating : 'No ratings'}</td>
        <td>${bench.userDisplayName}</td>
      </tr>
    `);

    return `
      <h3>Benches</h3>
      <table class="table">
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
            ${tableRowsHtml.join('')}
          </tbody>
      </table>    
    `;
  }

  return {
    getTableHtml
  };
})();
