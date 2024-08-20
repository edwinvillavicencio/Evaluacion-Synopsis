import { BrowserRouter, Routes, Route } from "react-router-dom";
import ShowClients from './components/ShowClients';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<ShowClients></ShowClients>}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
