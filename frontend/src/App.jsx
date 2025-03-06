import { Routes, Route } from "react-router-dom";
import Login from "./Login/Login";
import Register from "./Register/Register";
import Home from "./Home/Home";
import ClassManagerment from "./ClassManagerment/ClassManagerment";
import Statistics from "./Statistics/Statistics";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/home-page" element={<Home />} />
      <Route path="/class-managerment" element={<ClassManagerment />} />
      <Route path="/statistics" element={<Statistics />} />
    </Routes>
  );
}

export default App;
