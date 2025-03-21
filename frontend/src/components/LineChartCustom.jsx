import React, { useState } from "react";
import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import { Modal, Image } from "antd";

function LineChartCustom({ data }) {
  const [visible, setVisible] = useState(false);
  const [selectedImage, setSelectedImage] = useState("");

  const handleClick = (e) => {
    if (e && e.activePayload) {
      const clickedData = e.activePayload[0].payload;
      setVisible(true);
    }
  };

  return (
    <>
      <ResponsiveContainer width="100%" height="100%">
        <LineChart data={data} onClick={handleClick}>
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="logTime" stroke="#6366f1" />
          <YAxis stroke="#6366f1" domain={[0, 100]} />
          <Tooltip />
          <Line
            type="monotone"
            dataKey="studentCount"
            stroke="#6366f1"
            strokeWidth={2}
          />
        </LineChart>
      </ResponsiveContainer>
      <Image
        width={200}
        style={{
          display: "none",
        }}
        src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png?x-oss-process=image/blur,r_50,s_50/quality,q_1/resize,m_mfit,h_200,w_200"
        preview={{
          visible,
          src: "/data/logs/test.png",
          onVisibleChange: (value) => {
            setVisible(value);
          },
        }}
      />
    </>
  );
}

export default LineChartCustom;
