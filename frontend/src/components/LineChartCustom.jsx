import React from "react";
import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";

function LineChartCustom({ data }) {
  return (
    <ResponsiveContainer width="100%" height="100%">
      <LineChart data={data}>
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="time" stroke="#6366f1" />
        <YAxis stroke="#6366f1" domain={[0, 100]} />
        <Tooltip />
        <Line
          type="monotone"
          dataKey="count"
          stroke="#6366f1"
          strokeWidth={2}
        />
      </LineChart>
    </ResponsiveContainer>
  );
}

export default LineChartCustom;
