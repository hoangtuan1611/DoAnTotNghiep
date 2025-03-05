import { Routes, Route } from "react-router-dom";
import Login from "./Login/Login";
import Home from "./Home/Home";

function App() {
  return (
    <Routes>
      {/* <Route path="/" element={<Login />} /> */}
      <Route path="/" element={<Home />} />
      {/* <Route path="/home-page" element={<Home />} /> */}
    </Routes>
  );
}

export default App;
