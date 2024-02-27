import { useState, useEffect } from 'react';
import './App.css';
import Autocomplete from '@mui/material/Autocomplete';
import TextField from '@mui/material/TextField';

import { PersistenceService } from './services/persistence-service';
import { FAVORITES_KEY } from './helpers/constants';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import WeatherCard from './components/weather-card/WeatherCard';

function App() {
    const [favorites, setFavorites] = useState([]);
    const [weather, setWeather] = useState();
    const [location, setLocation] = useState('');
    const [suggestions, setSuggestions] = useState([]);

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
                    <Autocomplete
                        freeSolo
                        id='searchBar'
                        disableClearable
                        options={suggestions}
                        onInput={(i) => {
                            setWeather(undefined);
                            setLocation(i.target.value);
                        }}
                        onChange={(e) => {
                            setWeather(undefined);
                            setLocation(e.target.textContent);
                        }}
                        renderInput={(params) => (
                        <TextField
                            {...params}
                            placeholder='search city'
                            InputProps={{
                            ...params.InputProps,
                            type: 'search',
                            }}
                        />
                        )}
                    />
                    
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
        if (name === '' || name === null || name === undefined) {
            return;
        }
        const response = await fetch(`weatherforecast/GetWeather/${name}/metric`);
        return await response.json();
    }
    
    function drawFavorites() {
        const existingItems = PersistenceService.getData(FAVORITES_KEY) ?? [];
        setFavorites([]);
        
        var promises = [];
        var suggestions = [];
        if (existingItems.length > 0) {
            existingItems.forEach(element => {
                suggestions.push(`${element.name},${element.country}`);
                promises.push(populateWeatherData(`${element.name},${element.country}`));
            });

            setSuggestions(suggestions);
            Promise.all(promises).then(weathers => setFavorites(weathers))
        }
    }
}

export default App;