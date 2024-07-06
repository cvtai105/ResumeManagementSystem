// src/useFetch.js
import { useState, useEffect } from 'react';

const useFetch = (url) => {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(url);
        if(response.status === 404) {
            throw new Error('Not Found');
        }
        else if(response.status === 500) {
            throw new Error('Internal Server Error');
        }
        else if(response.status === 403) {
            throw new Error('Forbidden');
        }
        else if(response.status === 401) {
            //send refresh token
            throw new Error('Unauthorized');
        }
        else if(response.status === 400) {
            throw new Error('Bad Request');
        }
        else if(response.status === 200) {
            console.log('OK');
        }
        const result = await response.json();
        setData(result);
      } catch (error) {
        setError(error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [url]);

  return { data, loading, error };
};

export default useFetch;
