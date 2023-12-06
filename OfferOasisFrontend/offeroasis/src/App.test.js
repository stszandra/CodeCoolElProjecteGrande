import { render, screen } from '@testing-library/react';
import About from './About';


test('Please register first before you can place an order', () => {
  render(<About />);
  const textElements = screen.getAllByText(/Please register first before you can place an order/i);
  expect(textElements.length).toBeGreaterThan(0);
});
