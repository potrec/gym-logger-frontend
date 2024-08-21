import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils';
import ColorView from '../ColorView.vue';


describe('ColorView', () => {
    it('renders the component', () => {
        const wrapper = mount(ColorView);
        expect(wrapper.exists()).toBe(true);
    });

    it('displays the current theme', () => {
        const wrapper = mount(ColorView);
        const currentTheme = wrapper.find('.bg-page').text();
        expect(currentTheme).toContain('Current theme:');
    });

    it('changes the theme when a new theme is selected', async () => {
        const wrapper = mount(ColorView);
        const select = wrapper.find('select');
        const option = wrapper.find('option[value="dark"]');
        await select.setValue('dark');
        expect(option.element).toBe(true);
    });
});
