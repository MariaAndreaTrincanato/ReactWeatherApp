export class PersistenceService {
    static saveData(key, value) {
        localStorage.setItem(key, JSON.stringify(value));
    }

    static getData(key) {
        const res = localStorage.getItem(key);
        return res !== null ? JSON.parse(res) : null;
    }

    static clearData(key) {
        localStorage.removeItem(key);
    }

    static clearAll() {
        localStorage.clear();
    }
}
