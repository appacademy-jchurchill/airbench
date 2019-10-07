
(async () => {
  const benches = await airBenchData.getBenches();
  console.log(benches);

  const benchesDiv = document.getElementById('benches');
  benchesDiv.innerHTML = airBenchBenchesHtml.getTableHtml(benches);
})();
