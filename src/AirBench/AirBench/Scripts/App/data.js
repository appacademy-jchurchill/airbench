
const airBenchData = (() => {
  async function getData(resource) {
    const response = await fetch(`${airBenchConfig.baseApiUrl}/${resource}`);
    return await response.json();
  }

  async function getBenches()
  {
    return getData('benches');
  }

  return {
    getBenches
  };
})();
