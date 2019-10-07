
(async () => {
  const benchesDivId = 'benches';
  const benchFilteringId = 'bench-filtering';
  const minNumberOfSeatsInputId = 'minNumberOfSeats';
  const maxNumberOfSeatsInputId = 'maxNumberOfSeats';

  const benchesDiv = document.getElementById(benchesDivId);
  const benchFiltering = document.getElementById(benchFilteringId);
  const minNumberOfSeatsInput = document.getElementById(minNumberOfSeatsInputId);
  const maxNumberOfSeatsInput = document.getElementById(maxNumberOfSeatsInputId);

  const benches = await airBenchData.getBenches();

  benchesDiv.innerHTML = airBenchBenchesHtml.getTableHtml(benches);

  benchFiltering.addEventListener('keyup', (event) => {
    const minNumberOfSeats = parseInt(minNumberOfSeatsInput.value, 10);
    const maxNumberOfSeats = parseInt(maxNumberOfSeatsInput.value, 10);

    const filteredBenches = benches.filter(bench => 
      (isNaN(minNumberOfSeats) && isNaN(maxNumberOfSeats)) ||
      (isNaN(minNumberOfSeats) && bench.numberOfSeats <= maxNumberOfSeats) ||
      (isNaN(maxNumberOfSeats) && bench.numberOfSeats >= minNumberOfSeats) ||
      (bench.numberOfSeats >= minNumberOfSeats && bench.numberOfSeats <= maxNumberOfSeats)
    );

    benchesDiv.innerHTML = airBenchBenchesHtml.getTableHtml(filteredBenches);
  });
})();
