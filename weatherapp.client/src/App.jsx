import { useState, useEffect } from 'react';
import './App.css';
import { PersistenceService } from './services/persistence-service';
import { FAVORITES_KEY } from './helpers/constants';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import WeatherCard from './components/weather-card/WeatherCard';

function App() {
    const [favorites, setFavorites] = useState([]);
    const [weather, setWeather] = useState();
    const [location, setLocation] = useState('');

    useEffect(() => {
        drawFavorites();
    }, []);

    return (
        <div className='app'>
            {/* search area */}
            <div className='searchArea'>
                <div>
                    <h2>Weather App</h2>
                </div>

                <div className='searchFields'>
                    {/* TODO: must show favorite cities when searching*/}
                    <input 
                        id='searchBar' 
                        type='text'
                        placeholder='search'
                        onInput={(i) => {
                            setWeather(undefined);
                            setLocation(i.currentTarget.value)
                        }}>
                    </input>
                    <button 
                        id='searchButton'
                        onClick={() => populateWeatherData(location).then((data) => setWeather(data))}>
                            <FontAwesomeIcon icon={faMagnifyingGlass} />
                        </button>
                </div>
            </div>

            {/* weather info area */}
            <div className='infoArea'>
                <WeatherCard weather={weather} toggle={drawFavorites} isMain={true} />

                <div>
                    <h2>Favorites</h2>
                </div>
                <div className='favorites'>
                    {favorites?.map((weather) => <WeatherCard 
                                                    key={weather.name}
                                                    weather={weather}
                                                    toggle={drawFavorites}
                                                    isMain={false} />)  
                    } 
                </div>
            </div>
        </div>
    );

    async function populateWeatherData(name) {
        const response = await fetch(`weatherforecast/GetWeather/${name}/metric`);
        return await response.json();
    }
    
    function drawFavorites() {
        const existingItems = PersistenceService.getData(FAVORITES_KEY) ?? [];
        setFavorites([]);
        
        var promises = [];
        if (existingItems.length > 0) {
            existingItems.forEach(element => {
                promises.push(populateWeatherData(`${element.name},${element.country}`));
            });

            Promise.all(promises).then(weathers => setFavorites(weathers))
        }
    }
}

export default App;