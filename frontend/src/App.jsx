import { Routes, Route } from "react-router-dom";
import ProtectedRoute from "./ProtectedRoute";
import Login from "./Login/Login";
import Register from "./Register/Register";
import Home from "./Home/Home";
import ClassManagerment from "./ClassManagerment/ClassManagerment";
import Statistics from "./Statistics/Statistics";
import Schedule from "./Schedule/Schedule";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/register" element={<Register />} />

      <Route
        path="/home-page"
        element={
          <ProtectedRoute>
            <Home />
          </ProtectedRoute>
        }
      />
      <Route
        path="/class-managerment"
        element={
          <ProtectedRoute>
            <ClassManagerment />
          </ProtectedRoute>
        }
      />
      <Route
        path="/statistics"
        element={
          <ProtectedRoute>
            <Statistics />
          </ProtectedRoute>
        }
      />
      <Route
        path="/schedule"
        element={
          <ProtectedRoute>
            <Schedule />
          </ProtectedRoute>
        }
      />
    </Routes>
  );
}

export default App;
