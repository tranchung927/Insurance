import "./App.css";
import InsuranceRouter from "./Config/routers";
import { DataProvider } from "./Context/data-context";
function App() {
  return (
    <div className="App">
     <DataProvider><InsuranceRouter/></DataProvider>
    </div>
  );
}

export default App;
