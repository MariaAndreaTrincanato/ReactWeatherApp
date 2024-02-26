/* eslint-disable react/prop-types */
import './WeatherCard.css';
import { PersistenceService } from '../../services/persistence-service';
import { FAVORITES_KEY } from '../../helpers/constants';

import { useState, useEffect } from 'react';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faDroplet, faGauge, faStar as faStarSolid } from '@fortawesome/free-solid-svg-icons';
import { faStar as faStarRegular} from '@fortawesome/free-regular-svg-icons';

function WeatherCard(props) {
    const [favoriteIcon, setFavoriteIcon] = useState(faStarRegular);
    // const [forecasts, setForecasts] = useState();

    useEffect(() => {
        const showIcon = isFavorite(props.weather);
        if (showIcon) {
            setFavoriteIcon(faStarSolid);
        } else {
            setFavoriteIcon(faStarRegular);
        }
    }, [props.weather]);

    if (props.weather !== undefined) {
        return (
            <>
                <div className={props.isMain ? ['weatherCard', 'mainCard'].join(' ') : ['weatherCard'].join(' ')}>
                    <div className='cardRowName'>
                        <div className='cardRowNameText'>
                            <div className='cardRowNameFavorite'>
                                <span>{props.weather?.name}, {props.weather?.country}</span>
                                <FontAwesomeIcon
                                    id='favoriteIcon'
                                    icon={favoriteIcon}
                                    onClick={() => toggleFavorite(props.weather)}
                                    size='lg'/>
                            </div>
                            <span>{props.weather?.description?.description}</span>
                        </div>
                        <div>
                            <img src={props.weather?.description?.icon} width={110} height={110}/>
                        </div>
                    </div>
                    <div className='cardRowInfo'>
                        <span>Temperature: {props.weather.temperature} °C 
                            <span className='cardRowInfoDetail'>({props.weather.temperatureMin} °C - {props.weather.temperatureMax} °C)</span></span>
                        <span>Feels like: {props.weather.feelsLike} °C</span>
                        
                        <div className='cardRowInfoFooter'>
                            <span><FontAwesomeIcon
                                            id='favoriteIcon'
                                            icon={faDroplet}/> {props.weather.humidity}%</span>
                            <span><FontAwesomeIcon
                                        id='favoriteIcon'
                                        icon={faGauge}/> {props.weather.pressure} hPa</span>
                        </div>
                    </div>
                </div>
            </>
        );
    }
    return <></>;

    function toggleFavorite(weather) {
        if (weather === undefined || weather === null) {
            return;
        }

        let existingItems = PersistenceService.getData(FAVORITES_KEY) ?? [];
        console.log('existingItems', existingItems);
        if (existingItems.length > 0) {
            const exists = existingItems.map(x => `${x.name},${x.country}`)
                                            .includes(`${weather.name},${weather.country}`);
            if (exists) {
                const index = existingItems.indexOf(`${weather.name},${weather.country}`);
                if (index > -1) {
                    existingItems.splice(index, 1);
                }
                setFavoriteIcon(faStarRegular);
            } else {
                existingItems.push(weather)
                setFavoriteIcon(faStarSolid);
            }
        } else {
            existingItems.push(weather)
            setFavoriteIcon(faStarSolid);
        }

        PersistenceService.clearData(FAVORITES_KEY);
        PersistenceService.saveData(FAVORITES_KEY, existingItems);
        props.toggle();
    }

    function isFavorite(weather) {
        if (weather === undefined || weather === null) {
            return false;
        }

        const existingItems = PersistenceService.getData(FAVORITES_KEY) ?? [];
        if (existingItems.length > 0) {
            const includesName = existingItems.map(x => x.name).includes(weather.name);
            return existingItems !== null && includesName;
        }
        return false;
    }

    // async function populateForecastData(location) {
    //     const response = await fetch(`weatherforecast/GetForecast/${location}/metric`);
    //     const data = await response.json();
    //     setForecasts(data);
    // }
}

export default WeatherCard;
