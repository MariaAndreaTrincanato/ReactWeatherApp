import { useState } from 'react';
import './App.css';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';

function App() {
    // const [forecasts, setForecasts] = useState();
    const [weather, setWeather] = useState();
    const [location, setLocation] = useState('');

    return (
        <div>
            <div className='searchArea'>
                <div className='searchFields'>
                    <input 
                        id='searchBar' 
                        type='text' 
                        onInput={(i) => {
                            setLocation(i.currentTarget.value)
                        }}>
                    </input>
                    <button 
                        id='searchButton'
                        onClick={populateWeatherData}>
                            <FontAwesomeIcon icon={faMagnifyingGlass} />
                        </button>
                </div>
            </div>
            <p>
                {weather?.name}
            </p>
        </div>
    );
    
    async function populateWeatherData() {
        const response = await fetch(`weatherforecast/GetWeather/${location}/metric`);
        const data = await response.json();
        setWeather(data);
    }
}

export default App;