import React from "react";
import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";

function BarChartCustom({ data }) {
  return (
    <ResponsiveContainer width="100%" height="100%">
      <BarChart data={data}>
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="time" stroke="#6366f1" />
        <YAxis stroke="#6366f1" domain={[0, 100]} />
        <Tooltip />
        <Bar dataKey="count" fill="#6366f1" barSize={40} />
      </BarChart>
    </ResponsiveContainer>
  );
}

export default BarChartCustom;
